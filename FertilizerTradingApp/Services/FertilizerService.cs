﻿using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Services
{
	public class FertilizerService
	{
		private readonly FertilizerRepository _fertilizerRepository;
		public FertilizerService(string connectionString)
		{
			_fertilizerRepository = new FertilizerRepository(connectionString);
		}
		public bool AddFertilizer(string image, string name, float price, string category, int stock, string description)
		{
			return _fertilizerRepository.AddFertilizer(image, name, price, category, stock, description);
		}
		public List<Fertilizer> GetAllFertilizers()
		{
			return _fertilizerRepository.GetAllFertilizers();
		}
		public Fertilizer GetFertilizerById(string id)
		{
			return _fertilizerRepository.GetFertilizerById(id);
		}
	}
}
