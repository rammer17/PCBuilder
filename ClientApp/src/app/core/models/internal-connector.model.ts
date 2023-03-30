export type InternalConnectorGetResponse = {
  Id: number;
  Type: string;
  Quantity: number;
}[];

export type InternalConnectorAddRequest = {
  Type: string;
  Quantity: number;
};
