import React from 'react';

interface SideBarContextType {
    sideBar: boolean;
    setSideBar: React.Dispatch<React.SetStateAction<boolean>>;
}

export const SideBarContext = React.createContext<SideBarContextType>({} as SideBarContextType);