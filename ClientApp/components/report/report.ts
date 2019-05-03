import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface observation {
    patientId: string,
    Cholesterol: string
}

@Component
export default class Report extends Vue {
    observation: observation = <observation>{
        patientId: "",
        Cholesterol: ""
    }

    mounted() {
        this.getObservation;
    }

    getObservation(id: string) {
        let url = 'api/Observation/Get/' + id;
        axios({
            method: 'get',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            this.observation = response.data;
        })
            .catch((error: any) => {
                console.log(error);
            });
    }
}
