import type { SupplierDto } from "../suppliers/SupplierDto";

export interface OfferDto {
  id: number;
  brand: string;
  model: string;
  supplier: SupplierDto;
  registrationDate: Date;
}
