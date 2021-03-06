﻿import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

interface PractitionerList {
    Id: string,
    isActive: string,
    Gender: string
}

@Component
export default class PractitionerListComponent extends Vue {
    practitioners: PractitionerList[] = [];

    mounted() {
        this.getPractitioners();
    }

    getPractitioners() {
        axios({
            method: 'get',
            url: 'api/Practitioner/ShowAll'
        }).then((response: any) => {
            console.log(response.data);
            this.practitioners = response.data;
        })
            .catch((error: any) => {
                console.log(error);
            });
    }

    getThis(id: string) {
        this.$router.push('/practitioner/' + id);
    }
}
