using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CLUteisX.VForm
{
    public class BaseValidationViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        readonly IDictionary<string, List<string>> _errors;
        public bool HasErrors => 
            _errors?.Any(x => x.Value?.Any() == true) == true;
        public BaseValidationViewModel()
        {
            _errors =
            new Dictionary<string, List<string>>();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Any())
            {
                return _errors[propertyName];
            }

            return new List<string>();
        }

        public void Validate(object value, Func<bool> rule, string error, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return;
            }

            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }

            if(rule() == false)
            {
                _errors.Add(propertyName, new List<string> { error });
            }

            var validationContext = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var validationResults = new List<ValidationResult>();

            Validator.TryValidateProperty(value, validationContext, validationResults);

            if (validationResults.Count > 0)
            {
                foreach (var validation in validationResults)
                {
                    if (_errors.ContainsKey(propertyName))
                    {
                        _errors[propertyName].Add(validation.ErrorMessage);
                    }
                    else
                    {
                        _errors.Add(propertyName, new List<string> { validation.ErrorMessage });
                    }
                }
            }

            ErrorsChanged?.Invoke(this,
                new DataErrorsChangedEventArgs(propertyName));
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}
