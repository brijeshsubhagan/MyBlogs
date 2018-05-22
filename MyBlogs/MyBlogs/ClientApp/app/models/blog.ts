export class Blog {
    id: number;
    title: string;
    body: string;
    date: string;
    username: string;

    constructor() {
        this.id = 0;
        this.title = '';
        this.body = '';
        this.date = '';
        this.username = '';
    };
}