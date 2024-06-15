"use client";

import { Button } from "@/components/ui/button";
import { ArrowDownIcon, ArrowUpIcon } from "@radix-ui/react-icons";
import { ColumnDef } from "@tanstack/react-table";

export type FilterList = {
  id: number;
  name: string;
  description?: string | null;
  licenseId: number;
  syntaxIds: number[];
  languageIds: number[];
  tagIds: number[];
  primaryViewUrl?: string | null;
  maintainerIds: number[];
};

export const columns: ColumnDef<FilterList>[] = [
  {
    accessorKey: "name",
    header: ({ column }) => {
      const isSorted = column.getIsSorted();
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(isSorted === "asc")}
        >
          Name
          {isSorted === "asc" && <ArrowUpIcon className="ml-2 h-4 w-4" />}
          {isSorted === "desc" && <ArrowDownIcon className="ml-2 h-4 w-4" />}
        </Button>
      );
    },
  },
  {
    accessorKey: "description",
    header: ({ column }) => {
      const isSorted = column.getIsSorted();
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(isSorted === "asc")}
        >
          Description
          {isSorted === "asc" && <ArrowUpIcon className="ml-2 h-4 w-4" />}
          {isSorted === "desc" && <ArrowDownIcon className="ml-2 h-4 w-4" />}
        </Button>
      );
    },
  },
];
