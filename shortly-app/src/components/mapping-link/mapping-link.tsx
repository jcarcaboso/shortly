import type { Mapping } from "@/models/url-mapping";
import { useEffect, useState } from "react";

export const MappingLink = () => {
  const [mappings, setMappings] = useState<Mapping[]>([]);

  useEffect(() => {
    const fetchMappings = async () => {
      const rs = await fetch(`${import.meta.env.PUBLIC_BACKEND_HOST}/mapping`);
      const maps = (await rs.json()) as Mapping[];
      console.debug(maps);
      setMappings(maps);
    };

    fetchMappings();
  }, [mappings]);

  return (
    <div>
      {mappings.map((m) => {
        return (
          <div className="flex flex-row gap-2">
            <span>{m.id}</span>
            <span>{m.destination}</span>
          </div>
        );
      })}
    </div>
  );
};
