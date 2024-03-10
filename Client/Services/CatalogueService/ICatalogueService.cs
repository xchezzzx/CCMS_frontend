﻿using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.CatalogueService
{
    public interface ICatalogueService
    {
        //Services for categories
        Task<List<ExerciseCategoryDT>> GetAllExerciseCategoriesAsync();
        Task<ExerciseCategoryDT> GetExerciseCategoryByIdAsync(int id);
        Task<ExerciseCategoryDT> AddNewExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT);
        Task UpdateExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT);
        Task DeleteExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT);

        //Services for languages
        Task<List<ExerciseLangDT>> GetAllExerciseLanguagesAsync();
        Task<ExerciseLangDT> GetExerciseLanguageByIdAsync(int id);
        Task<ExerciseLangDT> AddNewExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT);
        Task UpdateExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT);
        Task DeleteExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT);

        //Services for platforms
        Task<List<ExercisePlatformDT>> GetAllExercisePlatformsAsync();
        Task<ExercisePlatformDT> GetExercisePlatformByIdAsync(int id);
        Task<ExercisePlatformDT> AddNewExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT);
        Task UpdateExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT);
        Task DeleteExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT);
    }
}