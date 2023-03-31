export type StorageSlotGetResponse = {
    id: number;
    type: string;
}[];

export type StorageSlotAddRequest = {
    type: string;
}