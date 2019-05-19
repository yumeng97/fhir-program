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
    lastUpdated: string,
    observations: Observations[]
}

interface Observations {
    id: string,
    type: string,
    value: string,
    effectiveDateTime: string
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
    monitored: Patient[] = [];

    mounted() {
        this.getPractitioner(this.$route.params.id);
        this.getPatients(this.$route.params.id);
        this.getMonitored(this.$route.params.id);
        this.autoRefresh(this.$route.params.id)
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

    getPatients(id: string) {
        let url = 'api/Patient/ShowNotMonitored/' + id;
        axios({
            method: 'get',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            console.log("not monitored");
            this.patients = response.data;
        })
            .catch((error: any) => {
                console.log(error);
            });
    }

    getMonitored(id: string) {
        let url = 'api/Patient/ShowMonitored/' + id;
        axios({
            method: 'get',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            console.log("monitored");
            this.monitored = response.data;
        })
            .catch((error: any) => {
                console.log(error);
            });
    }

    autoRefresh(id: string) {
        setInterval(() => {
            this.getMonitored(id);
        }, 3600000)
    }
 

    addToMonitored(patientId: string) {
        let url = 'api/Practitioner/AddPatientMonitor/' + this.$route.params.id + '/' + patientId;
        axios({
            method: 'put',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            let patient = this.searchParent(patientId, this.patients)
            this.monitored.push(patient);
            this.patients = this.patients.filter(patient => patient.id != patientId);

        })
            .catch((error: any) => {
                console.log(error);
            });
    }

    deleteFromMonitored(patientId: string) {
        let url = 'api/Practitioner/DeletePatientMonitor/' + this.$route.params.id + '/' + patientId;
        axios({
            method: 'put',
            url: url
        }).then((response: any) => {
            console.log(response.data);
            let patient = this.searchParent(patientId, this.monitored)
            this.patients.push(patient);
            this.monitored = this.monitored.filter(patient => patient.id != patientId);
        })
            .catch((error: any) => {
                console.log(error);
            });
    }

    searchParent(id: string, patients: Patient[]): Patient {
        let p = <Patient> {
            id: "",
            name: "",
            gender: "",
            address: "",
            lastUpdated: ""
        };
        for (let patient of patients) {
            if (patient.id == id) {
                return patient;
            }
        }
        return p;
    }
}
