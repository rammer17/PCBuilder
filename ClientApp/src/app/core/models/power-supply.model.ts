import { InternalConnectorGetResponse } from './internal-connector.model';

export type PowerSupplyGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  Type: string;
  EfficiencyRating: string;
  FormFactor: string;
  Wattage: number;
  Connectors: InternalConnectorGetResponse[];
}[];

export type PowerSupplyGetCompatibleRequest = {
  CaseId: number;
};

export type PowerSupplyAddRequest = {
  Manufacturer: string;
  Model: string;
  Type: string;
  EfficiencyRating: string;
  FormFactor: string;
  Wattage: number;
  InternalConnectorIds: number[];
};
