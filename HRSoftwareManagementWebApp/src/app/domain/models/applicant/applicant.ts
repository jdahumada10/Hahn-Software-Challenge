import { ProcessStatus } from "./processStatus";

export class Applicant {
    id?: string;
    firstName?: string;
    lastName?:string;
    email?:string;
    role?:string;
    processStatus?:ProcessStatus;
    companyId?:string;
  }