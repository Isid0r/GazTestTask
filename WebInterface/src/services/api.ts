import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { SearchResultDto } from "../DTOs/common/SearchResultDto";
import type { OfferDto } from "../DTOs/offers/OfferDto";
import type { PopularSupplierDto } from "../DTOs/suppliers/PopularSupplierDto";

export const api = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "/api",
  }),
  endpoints: (builder) => ({
    getOffers: builder.query<SearchResultDto<OfferDto>, { search?: string }>({
      query: ({ search }) => ({
        url: "offers/search",
        params: search ? { search } : {},
      }),
    }),

    getPopularSuppliers: builder.query<PopularSupplierDto[], void>({
      query: () => "suppliers/popular",
    }),
  }),
});

export const { useGetOffersQuery, useGetPopularSuppliersQuery } = api;
