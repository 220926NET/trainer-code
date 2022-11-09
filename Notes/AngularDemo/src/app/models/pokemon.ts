export interface Pokemon {
    name : string;
    level : number;
    trainerId : number;
    type? : string;
    disposition? : string | null;
    nickName ? : string;
    id? : number;
}