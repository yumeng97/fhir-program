﻿import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Practitioner {
    Id: string,
    isActive: string,
    Gender: string
}

@Component
export default class FetchDataComponent extends Vue {
    practitioners: Practitioner[] = [];

    mounted() {
        fetch('api/Practitioner/ShowAll')
            .then(response => response.json() as Promise<Practitioner[]>)
            .then(data => {
                this.practitioners = data;
                console.log(data);
            });
    }
}