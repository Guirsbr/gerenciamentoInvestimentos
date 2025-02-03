export interface Investimento {
    id?: number,
    valor_inicial: boolean,
    valor_atual: boolean,
    rentabilidade: string,
    data_atualizacao: string,
    data_investimento: string,
    id_banco: number,
    id_tipo_investimento: number,
    id_usuario: number,
}