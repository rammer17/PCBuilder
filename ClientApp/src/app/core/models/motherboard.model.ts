export type MotherboardGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  imageUrl: string;
  formFactor: string;
  socket: number;
  chipset: number;
  memorySlots: number;
  memoryType: string;
  memorySpeed: number;
  wifi: boolean;
};

export type MotherboardGetCompatibleRequest = {
  cpuId: number;
  ramId: number;
  caseId: number;
};

export type MotherboardAddRequest = {
  manufacturer: string;
  model: string;
  imageUrl: string;
  formFactor: string;
  socketId: number;
  chipsetId: number;
  memorySlots: number;
  memoryType: string;
  memorySpeed: number;
  wifi: boolean;
  portIds: number[];
  connectorIds: number[];
  storageSlotIds: number[];
};
