export type InternalConnectorGetResponse = {
  id: number;
  type: string;
  quantity: number;
};

export type InternalConnectorAddRequest = {
  type: string;
  quantity: number;
};
