export interface Category {
    id: number;
    name: string;
    number: number;
}

export interface Week {
    id: number; 
    quarter: number; 
    number: number; 
    year: number; 
    entries: Array<any>;
}

export interface WeekEntry {
    id: number;
    category: Category;
    week: Week;
    mon: number;
    tue: number;
    wed: number;
    thurs: number;
    fri: number;
    lastUpdated: string;
}

export interface SaveWeekEntry {
    id: number;
    categoryId: number;
    weekId: number;
    mon: number;
    tue: number;
    wed: number;
    thurs: number;
    fri: number;
}