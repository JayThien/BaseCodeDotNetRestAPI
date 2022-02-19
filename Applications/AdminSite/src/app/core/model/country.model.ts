export enum Country {
  Vietnam,
  Thailand,
  HongKong,
  Philippines,
  CzechRepublic,
  Slovakia,
}

export const COUNTRY_NAME = new Map<Country, string>([
  [Country.Vietnam, 'Vietnam'],
  [Country.Thailand, 'Thailand'],
  [Country.HongKong, 'Hong Kong'],
  [Country.Philippines, 'Philippines'],
  [Country.CzechRepublic, 'Czech Republic'],
  [Country.Slovakia, 'Slovakia'],
]);

export const COUNTRY_CODE = new Map<Country, string>([
  [Country.Vietnam, 'vn'],
  [Country.Thailand, 'th'],
  [Country.HongKong, 'hk'],
  [Country.Philippines, 'ph'],
  [Country.CzechRepublic, 'cz'],
  [Country.Slovakia, 'sl'],
]);

export const COUNTRY_FLAG = new Map<Country, string>([
  [Country.Vietnam, 'assets/images/flag/vietnam.png'],
  [Country.Thailand, 'assets/images/flag/thailand.png'],
  [Country.HongKong, 'assets/images/flag/hong-kong.png'],
  [Country.Philippines, 'assets/images/flag/philippines.png'],
  [Country.CzechRepublic, 'assets/images/flag/czech-republic.png'],
  [Country.Slovakia, 'assets/images/flag/slovakia.png'],
]);

export const COUNTRY_CURRENCY = new Map<Country, string>([
  [Country.Vietnam, 'VND'],
  [Country.Thailand, '฿'],
  [Country.HongKong, '$'],
  [Country.Philippines, '₱'],
  [Country.CzechRepublic, '€'],
  [Country.Slovakia, '€'],
]);

export const COUNTRIES: Country[] = [
  Country.Vietnam,
  Country.Thailand,
  Country.HongKong,
  Country.Philippines,
  Country.CzechRepublic,
  Country.Slovakia,
];
