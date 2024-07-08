//using Microsoft.AspNetCore.Components;
//using SmartWorkout.Entities;
//using SmartWorkout.Mappers;
//using SmartWorkout.Repositories.Interfaces;
//using WorkoutApp.DTOs;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using SmartWorkout.Repositories.Implementations;

//namespace SmartWorkout.Components.Pages
//{
//    public partial class AddOrEditExerciseLogs : ComponentBase
//    {
//        [Inject]
//        public IExerciseLogRepository ExerciseLogRepository { get; set; }

//        [Inject]
//        public NavigationManager NavigationManager { get; set; }

//        [Parameter]
//        public int ExerciseLogId { get; set; }

//        public ExerciseLogDto ExerciseLogDto { get; set; } = new ExerciseLogDto();
//        public ExerciseLog ExerciseLog { get; set; } = new ExerciseLog();

//        private bool IsEdit = false;

//        protected override async Task OnParametersSetAsync()
//        {
//            if (ExerciseLogId != 0)
//            {
//                ExerciseLog = await ExerciseLogRepository.GetByIdAsync(ExerciseLogId);
//                if (ExerciseLog != null)
//                {
//                    ExerciseLogDto = ExerciseLogMapper.ToExerciseLogDto(ExerciseLog);
//                    IsEdit = true;
//                }
//                else
//                {
//                    await InvokeAsync(() => NavigationManager.NavigateTo("/exerciseLogs"));
//                }
//            }
//        }

//        private async Task OnFormSubmitAsync()
//        {
//            try
//            {
//                var exerciseLog = ExerciseLogMapper.ToExerciseLog(ExerciseLogDto);
//                if (IsEdit)
//                {
//                    var trackedEntity = ExerciseLogRepository.GetTrackedEntity(exerciseLog.Id);
//                    if (trackedEntity != null)
//                    {
//                        ExerciseLogRepository.Detach(trackedEntity);
//                    }

//                    await ExerciseLogRepository.UpdateAsync(exerciseLog);
//                }
//                else
//                {
//                    await ExerciseLogRepository.AddAsync(exerciseLog);
//                }

//                await InvokeAsync(() => NavigationManager.NavigateTo("/exerciseLogs"));
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error saving user: {ex.Message}");
//            }
//        }

//    }
//}
