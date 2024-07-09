using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Mappers;
using SmartWorkout.Repositories.Interfaces;
using System.Diagnostics;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Pages
{
    public partial class AddOrEditExerciseLogs : ComponentBase
    {
        [Inject]
        public IExerciseLogRepository ExerciseLogRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int? ExerciseLogId { get; set; }

        [Parameter]
        public int? ExerciseId { get; set; }

        [Parameter]
        public int? WorkoutId { get; set; }

        public ExerciseLogDto ExerciseLogDto { get; set; } = new();
        public ExerciseLog ExerciseLog { get; set; } = new();

        private bool IsEdit = false;

        protected override async Task OnParametersSetAsync()
        {
            if (ExerciseLogId != null)
            {
                ExerciseLog = await ExerciseLogRepository.GetByIdAsync((int)ExerciseLogId);
                if (ExerciseLog != null)
                {
                    ExerciseLogDto = ExerciseLogMapper.ToExerciseLogDto(ExerciseLog);
                    IsEdit = true;
                }
                else
                {
                    await InvokeAsync(() => NavigationManager.NavigateTo("/exerciseLogs"));
                }
            }
            if (WorkoutId != null)
            {
                ExerciseLogDto.WorkoutId = (int)WorkoutId;
            }
            if (ExerciseId != null)
            {
                ExerciseLogDto.ExerciseId = (int)ExerciseId;
            }
        }

        private async Task OnFormSubmitAsync()
        {
            try
            {
                var exerciseLog = ExerciseLogMapper.ToExerciseLog(ExerciseLogDto);
                if (IsEdit)
                {
                    var trackedEntity = ExerciseLogRepository.GetTrackedEntity(exerciseLog.Id);
                    if (trackedEntity != null)
                    {
                        ExerciseLogRepository.Detach(trackedEntity);
                    }
                    await ExerciseLogRepository.UpdateAsync(exerciseLog);
                }
                else
                {
                    await ExerciseLogRepository.AddAsync(exerciseLog);
                }
                await InvokeAsync(() => NavigationManager.NavigateTo("/exerciseLogs"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }

    }
}
