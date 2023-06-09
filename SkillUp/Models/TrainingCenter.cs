﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SkillUp.Models
{
	public class TrainingCenter
	{
		public TrainingCenter()
		{
		}

        public int Id { get; set; }
        public string Name { get; set; }
		public Manager? manager { get; set; }
		public IEnumerable<TrainingCenter>? trainingCenters { get; set; }
    }
}

