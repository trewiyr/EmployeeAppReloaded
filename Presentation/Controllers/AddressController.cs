using Application.Dtos;
using Application.Services.Address;
using Application.Services.Department;
using Application.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoMapping;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Authorize]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService!;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                SetFlashMessage("Please fill in all required fields correctly.", "error");
                return View(model);
            }

            var viewModel = new CreateAddressDto
            {
                Id = Guid.NewGuid(),
                StreetNo = model.StreetNo,
                //State = model.State,
                StreetName = model.StreetName,
                City = model.City
            };

            var result = await _addressService.CreateAddressAsync(viewModel);

            if (result == null)
            {
                SetFlashMessage("An error occurred while creating the address. Please try again.", "error");
                return View(model);
            }

            SetFlashMessage("Address created successfully.", "success");

            return RedirectToAction(nameof(Index));
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddressViewModel model)
        {
            var address = new UpdateAddressDto
            {
                Id = Guid.NewGuid(),
                StreetNo = model.StreetNo,
                //State = model.State,
                StreetName = model.StreetName,
                City = model.City
            };

            var result = await _addressService.UpdateAddressAsync(address);

            if (result == null)
            {
                return View(model);
            }


            return RedirectToAction(nameof(Index));


        }
    
        public async Task<IActionResult> Delete(Guid id)
        {
            await _addressService.DeleteAddressAsync(id);

            try
            {
                SetFlashMessage("Deleted Succesfully!", "Success");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!ModelState.IsValid)
            {
                SetFlashMessage("Please fill in all required fields correctly.", "error");
                return View();
            }

            var result = await _addressService.GetAddressByIdAsync(id);
            if (result == null)
            {
                return View();
            }
            var viewModel = result.ToViewModel();
            return View(viewModel);

        }
    }


}
