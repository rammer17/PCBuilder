import { InternalConnectorGetResponse } from './internal-connector.model';

export type PowerSupplyGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  type: string;
  efficiencyRating: string;
  formFactor: string;
  wattage: number;
  connectors: InternalConnectorGetResponse[];
}[];

export type PowerSupplyGetCompatibleRequest = {
  caseId: number;
};

export type PowerSupplyAddRequest = {
  manufacturer: string;
  model: string;
  type: string;
  efficiencyRating: string;
  formFactor: string;
  wattage: number;
  internalConnectorIds: number[];
};
