namespace TaskBooking.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class CategoryController(ISender sender,
        ILogger<CategoryController> logger) : ControllerBase
    {

        [HttpGet("categories")]
        [ProducesResponseType(typeof(ListCategoryDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> FilterMovies( CancellationToken cancellationToken)
        {
            try
            {
                //[FromBody] TitleFilterModel filterModel
                //var query = new GetCategories.Query
                //{
                //    Title = filterModel.Title,
                //    PageNumber = filterModel.PageNumber,
                //    PageSize = filterModel.PageSize,
                //    SortDirection = filterModel.SortDirection,
                //    SortBy = filterModel.SortBy,
                //};
                var query = new GetCategories.Query
                {
                    Title = string.Empty,
                    PageNumber = 1,
                    PageSize = 10,
                    SortDirection = string.Empty,
                    SortBy = string.Empty,
                };
                var result = await sender.Send(query, cancellationToken);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{filterModel}", "filterModel");
                throw;

            }
        }

        [HttpGet("{categoryGuid:guid}")]
        [ProducesResponseType(typeof(GetCategoryDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetAsync(Guid categoryGuid, CancellationToken cancellationToken)
        {
            try
            {
                var result = await sender.Send(new GetCategoryByGUID.Query(categoryGuid), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching data with GUID: {categoryGuid}", categoryGuid);
                throw;
            }
        }

        [HttpPost("category")]
        [ProducesResponseType(typeof(CreateCategoryDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDTO create, CancellationToken cancellationToken)
        {
            try
            {
                await sender.Send(new CreateCategoryCommand.Command(create.Name, create.UrlHandle), cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{create}", create);
                throw;

            }
        }

        [HttpPut("{categoryGuid:guid}")]
        [ProducesResponseType(typeof(UpdateCategoryDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update(Guid categoryGuid, [FromBody] UpdateCategoryDTO update, CancellationToken cancellationToken)
        {
            try
            {
                var command = new UpdateCategoryCommand.Command(update.Name, update.UrlHandle, categoryGuid);
                command.CategoryGuid = categoryGuid;
                await sender.Send(command, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{update}", update);
                throw;

            }
        }

        [HttpDelete("{categoryGuid:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(Guid categoryGuid, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteCategoryCommand.Command(categoryGuid);

                await sender.Send(command, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{categoryGuid}", categoryGuid);
                throw;

            }
        }
    }
}