import React from 'react';

interface LanguageContextType {
    langRO: boolean;
    setLangRO: React.Dispatch<React.SetStateAction<boolean>>;
}

export const LanguageContext = React.createContext<LanguageContextType>({} as LanguageContextType);