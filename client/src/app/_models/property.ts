import { Photo } from "./photo";

export interface Property {
    id: number;
    address: string;
    city: string;
    state: string;
    zip: string;
    acquisitionDate: Date;
    acquisitionValue: number;
}