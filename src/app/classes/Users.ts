export class Users{
    constructor(
            public tz?:string,
            public firstName?:string,
            public lastName?:string,
            public password?:string,
            public mail?:string,
            public phone?:string,
            public lat?:number,
            public lng?:number,
    ){}
}