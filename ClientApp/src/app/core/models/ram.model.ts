export type RamGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  capacity: number;
  frequency: number;
  type: string;
  timing: string;
};

export type RamGetCompatibleRequest = {
  motherboardId: number;
};

export type RamAddRequest = {
  manufacturer: string;
  model: string;
  capacity: number;
  frequency: number;
  type: string;
  timing: string;
};
