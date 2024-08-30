<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Final_Retail.Models;

using System.Threading.Tasks;
using Final_Retail.Services;

namespace Final_Retail.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync("Orders");
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync("Orders", id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CustomerId,Quantity,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrUpdateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync("Orders", id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RowKey,ProductId,CustomerId,Quantity,OrderDate")] Order order)
        {
            if (id != order.RowKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderService.AddOrUpdateOrderAsync(order);
                }
                catch
                {
                    if (!await OrderExists(order.RowKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync("Orders", id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _orderService.DeleteOrderAsync("Orders", id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderExists(string id)
        {
            var order = await _orderService.GetOrderAsync("Orders", id);
            return order != null;
        }
    }
}
=======
﻿using Microsoft.AspNetCore.Mvc;
using Final_Retail.Models;

using System.Threading.Tasks;
using Final_Retail.Services;

namespace Final_Retail.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync("Orders");
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync("Orders", id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CustomerId,Quantity,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrUpdateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync("Orders", id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RowKey,ProductId,CustomerId,Quantity,OrderDate")] Order order)
        {
            if (id != order.RowKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderService.AddOrUpdateOrderAsync(order);
                }
                catch
                {
                    if (!await OrderExists(order.RowKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync("Orders", id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _orderService.DeleteOrderAsync("Orders", id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderExists(string id)
        {
            var order = await _orderService.GetOrderAsync("Orders", id);
            return order != null;
        }
    }
}
>>>>>>> 1c0e17787d4e6a4bebdd1ef0692a2fa41b7378a6
