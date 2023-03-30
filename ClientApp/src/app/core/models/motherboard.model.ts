export type MotherboardGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  FormFactor: string;
  SocketId: number;
  ChipsetId: number;
  MemorySlots: number;
  MemoryType: string;
  MemorySpeed: number;
  Wifi: boolean;
}[];

export type MotherboardGetCompatibleRequest = {
  CpuId: number;
  RamId: number;
  CaseId: number;
};

export type MotherboardAddRequest = {
  Manufacturer: string;
  Model: string;
  FormFactor: string;
  SocketId: number;
  ChipsetId: number;
  MemorySlots: number;
  MemoryType: string;
  MemorySpeed: number;
  Wifi: boolean;
  PortIds: number[];
  ConnectorIds: number[];
  StorageSlotIds: number[];
};
