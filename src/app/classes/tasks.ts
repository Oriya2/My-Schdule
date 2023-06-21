import { Time } from "@angular/common";
import { FlowArrayMutation } from "typescript";

export class tasks {
        constructor(
                public code?: number,
                public DateInsert?: Date,
                public RangeDays?: number,
                public tzClient?: string,
                public tzProfessional?: string,
                public startTime?: Date,
                public endTime?: Date,
                public requireStatus?: number,
                public nameProfessional?: string,
                public nameClient?: string,
                public massage?: string,

                 public   nameAbilityCode?:string,
                public yes?: boolean,
                public typeAbilityCode?: number,
                public abilityName?:string
        ) { }
}