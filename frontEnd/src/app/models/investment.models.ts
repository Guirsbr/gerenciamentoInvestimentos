export interface Investment {
    id?: number,
    initial_value: boolean,
    current_value: boolean,
    rentability: string,
    update_date: string,
    registration_date: string,
    id__bank?: number,
    bank_name: string,
    id__investment_type?: number,
    investment_type_name: string,
}