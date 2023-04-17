import { Company } from "src/app/domain/models/company/company";

export class CompanyMapper {
  
  public static mapResponseFromApiToCompany(companyList: any): any {
    return companyList.value.map((company: {
      id: string;
      name: string;
      address: string;
    }) => {
      var mappedCompany: Company = {
        id: company.id,
        name: company.name,
        address: company.address
      };
      return mappedCompany;
    });
  }

  public static mapFromCompanyEntityToApi(company: Company): any {
    const selectedCompany = {
      id: company.id,
      name: company.name,
      address: company.address
    }
    return selectedCompany;
  }
}