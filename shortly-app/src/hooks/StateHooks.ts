import { create } from 'zustand'
import type { Mapping } from '@/models/url-mapping'

interface MappingsState {
    mappings: Mapping[],
    add: (mapping: Mapping) => void,
    remove: (id: string) => void,
}

export const useStore = create<MappingsState>((set) => ({
    mappings: [],
    add: (mapping: Mapping) => set(state => ({ mappings: [...state.mappings, mapping] })),
    remove: (id: string) => set(state => ({ mappings: state.mappings.filter(m => m.id === id) })),
}))