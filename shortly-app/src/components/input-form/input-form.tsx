import React, { useState } from "react";
import { Button } from "../ui/button";
import { Input } from "../ui/input";
import { Label } from "../ui/label";

interface AddMappingForm {
  address: string;
}

export const InputForm = () => {
  const [form, setForm] = useState<AddMappingForm>({ address: "" });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const url = `${import.meta.env.PUBLIC_BACKEND_HOST}/mapping?url=${encodeURIComponent(form.address)}`;

    const rs = await fetch(url, {
      method: "POST",
    });
    const id = await rs.text();
  };

  return (
    <form onSubmit={(e) => handleSubmit(e)} className="flex flex-col gap-2 p-4">
      <Label htmlFor="address" className="pl-4">
        Insert URL
      </Label>
      <div className="flex flex-row gap-2">
        <Input
          required
          placeholder="Insert URL"
          type="url"
          id="address"
          name="address"
          value={form.address}
          onChange={(e) => handleChange(e)}
        />
        <Button type="submit">Add</Button>
      </div>
    </form>
  );
};
