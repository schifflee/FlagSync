﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FlagSync.Core;
using System.Collections.Generic;

namespace FlagSync.View
{
    public class JobSettingsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<JobSettingViewModel> jobSettings = new ObservableCollection<JobSettingViewModel>();
        private JobSettingViewModel selectedJobSetting;

        /// <summary>
        /// Gets the job settings.
        /// </summary>
        /// <value>The job settings.</value>
        public ObservableCollection<JobSettingViewModel> JobSettings
        {
            get
            {
                return this.jobSettings;
            }
        }

        /// <summary>
        /// Gets the inter job settings.
        /// </summary>
        /// <value>The inter job settings.</value>
        public IEnumerable<JobSetting> InternJobSettings
        {
            get
            {
                foreach (JobSettingViewModel setting in this.JobSettings)
                {
                    yield return setting.Intern;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected job setting.
        /// </summary>
        /// <value>The selected job setting.</value>
        public JobSettingViewModel SelectedJobSetting
        {
            get
            {
                return this.selectedJobSetting;
            }

            set
            {
                if(this.SelectedJobSetting != value)
                {
                    this.selectedJobSetting = value;
                    this.OnPropertyChanged("SelectedJobSetting");
                }
            }
        }

        /// <summary>
        /// Adds the new job setting.
        /// </summary>
        public void AddNewJobSetting()
        {
            this.JobSettings.Add(new JobSettingViewModel("New Job " + (this.JobSettings.Count + 1)));
        }

        /// <summary>
        /// Deletes the selected job setting.
        /// </summary>
        public void DeleteSelectedJobSetting()
        {
            this.jobSettings.Remove(this.SelectedJobSetting);

            if(this.JobSettings.Count == 0)
            {
                this.AddNewJobSetting();
            }

            this.SelectedJobSetting = this.JobSettings[this.JobSettings.Count - 1];
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when a property has been changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}