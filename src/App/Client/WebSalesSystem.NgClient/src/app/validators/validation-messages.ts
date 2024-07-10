import { ɵLocalizeFn } from '@angular/localize';
export class ValidationMessages {
    static readonly required: () => string = () => $localize`:@@validationMessages_required:Field is required`;
    static readonly empty: () => string = () => $localize`:@@validationMessages_empty:Field cannot be empty`;
    static readonly stringLength: (fieldName: string, gender: string, minLength: number, maxLength: number) => string = (fieldName: string, gender: string, minLength: number, maxLength: number) => $localize`:@@validationMessages_stringLength:${selectGender(gender, { 'male': 'El', 'female': 'La' })}:gender: ${fieldName.toLowerCase()}:fieldName: must be between ${minLength}:minLength: and ${maxLength}:maxLength: ${selectPlural(maxLength, { '=1' : $localize`:@@validationMessages_character:character`, 'other' : $localize`:@@validationMessages_characters:characters` })}:plural: long`;
    static readonly stringMinLength: (fieldName: string, gender: string, minLength: number) => string = (fieldName: string, gender: string, minLength: number) => $localize`:@@validationMessages_stringMinLegth:${selectGender(gender, { 'male': 'El', 'female': 'La' })}:gender: ${fieldName.toLowerCase()}:fieldName: must be greater than ${minLength}:minLength: ${selectPlural(minLength, { '=1' : $localize`:@@validationMessages_character:character`, 'other' : $localize`:@@validationMessages_characters:characters` })}:plural: long`;
    static readonly stringMaxLength: (fieldName: string, gender: string, maxLength: number) => string = (fieldName: string, gender: string, maxLength: number) => $localize`:@@validationMessages_stringMaxLength:${selectGender(gender, { 'male': 'El', 'female': 'La' })}:gender: ${fieldName.toLowerCase()}:fieldName: must be less than ${maxLength}:maxLength: ${selectPlural(maxLength, { '=1' : $localize`:@@validationMessages_character:character`, 'other' : $localize`:@@validationMessages_characters:characters` })}:plural: long`;
    static readonly numberLength: (fieldName: string, gender: string, minLength: number, maxLength: number) => string = (fieldName: string, gender: string, minLength: number, maxLength: number) => $localize`:@@validationMessages_numberLength:Value of ${selectGender(gender, { 'male': 'del', 'female': 'de la' })}:gender: ${fieldName.toLowerCase()}:fieldName: must be between ${minLength}:minLength: and ${maxLength}:maxLength:`;
    static readonly numberMinLength: (fieldName: string, gender: string, minLength: number) => string = (fieldName: string, gender: string, minLength: number) => $localize`:@@validationMessages_numberMinLength:Value of ${selectGender(gender, { 'male': 'del', 'female': 'de la' })}:gender: ${fieldName.toLowerCase()}:fieldName: must be greater than ${minLength}:minLength:`;
    static readonly numberMaxLength: (fieldName: string, gender: string, maxLength: number) => string = (fieldName: string, gender: string, maxLength: number) => $localize`:@@validationMessages_numberMaxLength:Value of ${selectGender(gender, { 'male': 'del', 'female': 'de la' })}:gender: ${fieldName.toLowerCase()}:fieldName: must be less than ${maxLength}:maxLength:`;
    static readonly invalidEmail: () => string = () => $localize`:@@validationMessages_invalidEmail:Enter a valid e-mail address`;
}

export class GenderType { 
    static readonly male: string = 'male';
    static readonly female: string = 'female';
    static readonly none: string = 'none';
}

export interface GenderOptions {
  [key: string]: string;
}

export function selectGender(gender: string, options: GenderOptions): string {
    if (gender in options) {
        return options[gender];
    } else {
        return '';
    }
}

export interface PluralOptions {
  [key: string]: string;
}

function selectPlural(count: number, options: PluralOptions): string {
  let optionKey: string;

  if (count === 0) {
    optionKey = '=0';
  } else if (count === 1) {
    optionKey = '=1';
  } else if (count === 2) {
    optionKey = '=2';
  } else {
    optionKey = 'other';
  }

  if (optionKey in options) {
    return options[optionKey];
  } else {
    return '';
  }
}