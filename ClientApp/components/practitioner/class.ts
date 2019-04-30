import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Practitioner {
    Id: string,
    MaritalStatus: string,
    Gender: string
}

@Component
export default class FetchDataComponent extends Vue {
    practitioners: Practitioner[] = [];

    mounted() {
        fetch('api/Yeet/Yeeting/3')
            .then(response => response.json() as Promise<Practitioner[]>)
            .then(data => {
                this.practitioners = data;
                console.log(data);
            });
    }
}
