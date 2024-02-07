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
    <form
      onSubmit={(e) => handleSubmit(e)}
      className="flex flex-row gap-2 p-1 items-center bg-green-800"
    >
      <Label htmlFor="address">Insert URL</Label>
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
    </form>
  );
};
