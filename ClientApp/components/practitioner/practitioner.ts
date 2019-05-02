import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface Practitioner {
    id: string,
    name: string
    isActive: string,
    gender: string,
    address: string,
    lastUpdated: string
}

interface Patient {
    id: string,
    name: string
    gender: string,
    address: string,
    lastUpdated: string
}

@Component
export default class PractitionerListComponent extends Vue {
    practitioner: Practitioner = <Practitioner>{
        id: "",
        isActive: "",
        gender: "",
        address: "",
        lastUpdated: "",
        name: ""
    }

    patients: Patient[] = [];

    mounted() {
        this.getPractitioner(this.$route.params.id);
        this.getPatients();
    }

    getPractitioner(id: string) {
        let url = 'api/Practitioner/Get/' + id;
        axios({
            method: 'get',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            this.practitioner.id = response.data.id;
            this.practitioner.name = response.data.name.givenName + " " + response.data.name.familyName;
            this.practitioner.isActive = response.data.active;
            this.practitioner.gender = response.data.gender;
            this.practitioner.lastUpdated = response.data.lastUpdated;
            this.practitioner.address = response.data.address.line + ", " + response.data.address.city + ", " + response.data.address.state 
                                            + ", " + response.data.address.postalCode + " " + response.data.address.country;

        })
            .catch((error: any) => {
                console.log(error);
            });
    }

    getPatients() {
        axios({
            method: 'get',
            url: 'api/Patient/ShowAll'
        }).then((response: any) => {
            console.log(response.data);
            this.patients = response.data;
        })
            .catch((error: any) => {
                console.log(error);
            });
    }
}
