import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Practitioner {
    Id: string,
    name: string
    isActive: string,
    Gender: string,
    address: string,
    lastUpdated: string
}

@Component
export default class PractitionerListComponent extends Vue {
    practitioner: Practitioner = <Practitioner>{
        Id: "",
        isActive: "",
        Gender: ""
    }

    mounted() {
        this.getPractitioner(this.$route.params.id);
    }

    getPractitioner(id: string) {
        let url = 'api/Practitioner/Get/' + id;
        axios({
            method: 'get',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            this.practitioner = response.data;
        })
            .catch((error: any) => {
                console.log(error);
            });
    }
}
