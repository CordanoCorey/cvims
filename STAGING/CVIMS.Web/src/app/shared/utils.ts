export function findSchoolYear(): string {
    const date = new Date();
    const year = date.getFullYear();
    const month = date.getMonth();
    return month >= 7 ? `${year}-${year + 1}` : `${year - 1}-${year}`;
}
