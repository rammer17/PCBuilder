export type StorageGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  type: string;
  capacity: number;
  formFactor: string;
  readSpeed: number;
  writeSpeed: number;
  interface: string;
}[];

export type StorageAddRequest = {
  manufacturer: string;
  model: string;
  type: string;
  capacity: number;
  formFactor: string;
  readSpeed: number;
  writeSpeed: number;
  interface: string;
};
