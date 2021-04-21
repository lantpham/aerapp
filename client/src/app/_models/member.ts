import { Photo } from "./photo";

export interface Member {
    id: number;
    username: string;
    age: number;
    name: string;
    gender: string;
    company: string;
    email: string;
    phone: string;
    photoUrl: string;
    address: string;
    dateofbirth: Date;
    photos: Photo[];
}