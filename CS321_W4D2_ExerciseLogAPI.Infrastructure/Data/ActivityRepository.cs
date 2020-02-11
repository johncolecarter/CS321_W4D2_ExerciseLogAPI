using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity newActivity)
        {
            _dbContext.Activities.Add(newActivity);
            _dbContext.SaveChanges();
            return newActivity;
        }

        public Activity Get(int id)
        {
            return _dbContext.Activities
                .Include(activity => activity.User)
                .Include(activity => activity.ActivityType)
                .SingleOrDefault(activity => activity.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activities
                .Include(activity => activity.User)
                .Include(activity => activity.ActivityType)
                .ToList();
        }

        public void Remove(Activity activity)
        {
            _dbContext.Activities.Remove(activity);
            _dbContext.SaveChanges();
        }

        public Activity Update(Activity updatedActivity)
        {
            var currentActivity = _dbContext.Activities.FirstOrDefault(x => x.Id == updatedActivity.Id);

            if (currentActivity == null) return null;

            _dbContext.Entry(currentActivity)
                .CurrentValues
                .SetValues(updatedActivity);

            _dbContext.Update(currentActivity);
            _dbContext.SaveChanges();
            return currentActivity;
        }
        public IEnumerable<Activity> UsersforActivity(int userId)
        {
            return _dbContext.Activities
                .Include(activity => activity.User)
                .Include(activity => activity.ActivityType)
                .Where(a => a.Id == userId).ToList();
        }
    }
}
