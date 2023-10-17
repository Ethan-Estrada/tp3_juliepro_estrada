using JuliePro.Services;
using JuliePro_DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JuliePro.Models
{


    public class TrainerSearchViewModel : TrainerSearchViewModelFilter
    {

        public TrainerSearchViewModel()
        {

        }

        public TrainerSearchViewModel(TrainerSearchViewModelFilter filter)
        {
            this.SelectedDisciplineId = filter.SelectedDisciplineId == 0 ? null: filter.SelectedDisciplineId;
            this.SelectedCertificationId = filter.SelectedCertificationId == 0 ? null : filter.SelectedCertificationId;
            this.SelectedPageSize = filter.SelectedPageSize == 0 ? 9 : filter.SelectedPageSize ;
            this.SelectedPageIndex = filter.SelectedPageIndex;
            this.SelectedGender = filter.SelectedGender;
            this.SearchNameText = filter.SearchNameText?.Trim() == String.Empty ? null : filter.SearchNameText;
            this.SelectedCertificationCenter = filter.SelectedCertificationCenter?.Trim() == String.Empty ? null : filter.SelectedCertificationCenter;
        }

        [Display(Name = "Items")] public IPaginatedList<Trainer> Items { get; set; }
        [Display(Name = "Disciplines")] public SelectList Disciplines { get; set; }
        [Display(Name = "Certifications")] public SelectList Certifications { get; set; }
        [Display(Name = "CertificationCenters")] public SelectList CertificationCenters { get; set; }
        [Display(Name = "AvailablePageSizes")] public SelectList AvailablePageSizes { get; set; }

    }

}
