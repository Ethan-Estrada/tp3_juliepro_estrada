using JuliePro.Models;
using JuliePro_DataAccess;
using JuliePro_DataModels;
using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services.impl
{
    public class TrainerService : ServiceBaseEF<Trainer>, ITrainerService
    {
        private IImageFileManager fileManager;

        public TrainerService(JulieProDbContext dbContext, IImageFileManager fileManager) : base(dbContext)
        {
            this.fileManager = fileManager;

        }

        public async Task<Trainer> CreateAsync(Trainer model, IFormCollection form)
        {
            model.Photo = await fileManager.UploadImage(form, false, null);

            return await base.CreateAsync(model);

        }

        public async Task EditAsync(Trainer model, IFormCollection form)
        {
            var old = await _dbContext.Trainers.Where(x=>x.Id == model.Id).Select(x=>x.Photo).FirstOrDefaultAsync();
            model.Photo = await fileManager.UploadImage(form, true, old);
            await this.EditAsync(model);

        }

        public async Task<TrainerSearchViewModel> GetAllAsync(TrainerSearchViewModelFilter filter)
        {


            var result = new TrainerSearchViewModel(filter);

            result.Items = await this._dbContext.Trainers

                .Where(x => result.SearchNameText == null || (x.FirstName+" "+x.LastName).ToLower().Contains(result.SearchNameText.ToLower()))
                .Where(x=> result.SelectedDisciplineId == null || x.Discipline_Id == result.SelectedDisciplineId)
                .Where(x => result.SelectedCertificationId == null || x.TrainerCertification.Any(y=>y.Certification_Id==result.SelectedCertificationId))
                .Where(x=> result.SelectedCertificationCenter == null || x.TrainerCertification.Any(y=>y.Certification.CertificationCenter == result.SelectedCertificationCenter))
                .Where(x=>result.SelectedGender == null || x.Genre == result.SelectedGender)
                .ToPaginatedAsync(result.SelectedPageIndex, result.SelectedPageSize);


            result.AvailablePageSizes = new SelectList(new List<int>() { 9, 12, 18, 21 });
            result.Disciplines = new SelectList(await this._dbContext.Disciplines.Where(x=>x.Trainers.Any()).ToListAsync(), "Id", "Name");
            result.Certifications = new SelectList(await this._dbContext.Certifications.Where(x => x.TrainerCertification.Any()).ToListAsync(), "Id", "FullTitle");
            result.CertificationCenters = new SelectList(await this._dbContext.Certifications.Where(x => x.TrainerCertification.Any()).Select(x=>x.CertificationCenter).Distinct().ToListAsync());


            return result;

        }
    }
}
