import React, { useState } from "react";
import { Button } from "../ui/button";
import { Input } from "../ui/input";

interface AddMappingForm {
  address: string;
}

export const InputForm = () => {
  const [form, setForm] = useState<AddMappingForm>({ address: "" });

  const handleSubmit = async (event: React.FormEvent) => {
    const url = `${import.meta.env.PUBLIC_BACKEND_HOST}/mapping?url=http%3A%2F%2Flocalhost%3A5242`;

    const rs = await fetch(url, {
      method: "POST",
    });
    // const id = await rs.json();
    console.log(rs);
  };

  return (
    <form onSubmit={(e) => handleSubmit(e)} className="flex flex-row gap-2 p-1">
      <Input placeholder="Insert URL" type="text" id="address" required />
      <Button type="submit">Add</Button>
    </form>
  );
};
