export interface Investment {
    id?: number,
    initial_value: number | string,
    current_value: number | string,
    rentability: string,
    update_date: string,
    registration_date: string,
    id__bank?: number,
    bank_name: string,
    id__investment_type?: number,
    investment_type_name: string,
}