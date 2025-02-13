export interface User {
    id?: number,
    name: string | null,
    email: string | null,
    password: string | null,
    registration_date?: string,
}