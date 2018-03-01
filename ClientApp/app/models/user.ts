export interface School {
    id: number;
    name: string;
}

export interface User {
    id: number; 
    firstname: string; 
    lastname: string;
    email: string; 
    school: School;
    auth0Id: string;
}

export interface SaveUser {
    id: number; 
    firstname: string; 
    lastname: string;
    email: string; 
    schoolid: number;
    auth0Id: string;
}