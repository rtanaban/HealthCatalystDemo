/// SEARCH RESULTS
class PeopleSearchResult extends React.Component {
	constructor(props) {
		super(props);
	}

	render() {
		const people = this.props.people;
		return (
			<div>
				{
					people.map((p, index) => {
						const interests = $.map(p.Interests, (interest) => { return interest.Name; }).join(', ');
						return (
							<div className="col-md-4" key={index}>
								<div className="panel panel-default">
									<table className="table table-bordered bg-success">
										<thead className="thead-light">
											<tr>
												<th scope="col-lg">{p.FirstName} {p.LastName}</th>
												<th scope="col-lg"><img src={"http://localhost:59854/Content/Images/" + p.Picture} /></th>
											</tr>
										</thead>
										<tbody>
											<tr>
												<td>
													Age:
												</td>
												<td>
													{p.Age}
												</td>
											</tr>
											<tr>
												<td>
													Address:
												</td>
												<td>
													{p.Address}
													<br />
													{p.City}, {p.State} {p.Zip}
												</td>
											</tr>
											<tr>
												<td>
													Interests:
												</td>
												<td>
													{interests}
												</td>
											</tr>
										</tbody>
									</table>
								</div>
							</div>);
					})
				}
			</div>
		)
	}
}


/// SEARCH INPUT TEXTBOX
class PeopleSearchInput extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			name: ''
		}
		this.handleChange = this.handleChange.bind(this);
	}

	handleChange(e) {
		this.props.onTextChange(e.target.value);
		this.setState({ name: e.target.value });
	}

	render() {
		name = this.state.name;
		return (
			<input type="text" className="input-lg form-inline" placeholder="Search by Name" aria-label="large"
				value={name} onChange={this.handleChange} />
		)
	}
}


/// MAIN SEARCH FORM
class PeopleSearchForm extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			name: '',
			people: []
		};

		this.handleChange = this.handleChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
	}

	handleChange(event) {
		this.setState({ name: event });
	}

	handleSubmit(event) {
		axios.get("http://localhost:59854/api/person/" + this.state.name).then(response => {
			this.setState({
				people: response.data
			});
		});
		event.preventDefault();
	}

	render() {
		const name = this.state.name;
		return (
			<div>
				<div className="panel panel-default">
					<div className="col-md-10 table table-bordered bg-info">
						<h1>People Search Demo</h1>
						<p>
							Please enter the first name, last name, or a substring for either name (e.g., "o", "in", "ian", "an", "ar", "ana", "el", "ve", etc.) in the text box.
						</p>
						<p>
							Submitting the form with an empty textbox input will display all the users (10 total) in the database.
						</p>
						<hr className="my-4" />
						<p className="lead">
							<form onSubmit={this.handleSubmit}>
								<PeopleSearchInput onTextChange={this.handleChange} />
								<a className="btn btn-primary btn-lg" href="#" role="button" onClick={this.handleSubmit}>Search</a>
							</form>
						</p>
					</div>
				</div>
				<p>&nbsp;</p>
				<PeopleSearchResult people={this.state.people} />
			</div>
		)
	}
}

ReactDOM.render(<PeopleSearchForm />, document.getElementById('searchForm'));
